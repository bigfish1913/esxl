@echo off
setlocal enabledelayedexpansion

echo ========================================
echo Excel文件处理工具 - 自动发布脚本
echo ========================================

:: 检查必要工具
where dotnet >nul 2>&1
if %errorlevel% neq 0 (
    echo 错误: 未找到 dotnet 工具，请先安装 .NET SDK
    pause
    exit /b 1
)

where git >nul 2>&1
if %errorlevel% neq 0 (
    echo 错误: 未找到 git 工具，请先安装 Git
    pause
    exit /b 1
)

:: 检查app.config文件是否存在
if not exist "app.config" (
    echo 错误: 找不到 app.config 文件
    pause
    exit /b 1
)

echo 正在提取版本号...
:: 使用PowerShell提取版本号
for /f %%i in ('powershell -Command "(Select-Xml -Path app.config -XPath '//add[@key=\"Version\"]/@value').Node.Value"') do set "version=%%i"

if "!version!"=="" (
    echo 错误: 无法从app.config中提取版本号
    pause
    exit /b 1
)

echo 当前版本号: !version!

:: 验证版本号格式
echo !version! | findstr "^[0-9]\.[0-9]\.[0-9]$" >nul
if %errorlevel% neq 0 (
    echo 警告: 版本号格式可能不正确，应为 x.y.z 格式 (例如 1.0.0)
    echo 当前版本号: !version!
    echo 是否继续？(y/n)
    set /p continue=
    if /i not "!continue!"=="y" (
        echo 已取消发布
        pause
        exit /b 1
    )
)

:: 创建发布目录
if not exist "releases" mkdir "releases"

echo.
echo 正在以Release模式编译项目...
dotnet publish -c Release -o ./publish --self-contained -r win-x64

if %errorlevel% neq 0 (
    echo 错误: 编译失败
    pause
    exit /b %errorlevel%
)

echo.
echo 正在打包发布文件...
:: 创建版本目录
set "release_dir=releases\!version!"
if not exist "%release_dir%" mkdir "%release_dir%"

:: 检查publish目录是否为空
if not exist "publish\*" (
    echo 错误: 编译后的文件不存在
    pause
    exit /b 1
)

:: 打包发布文件
powershell -Command "Compress-Archive -Path ./publish/* -DestinationPath '%release_dir%\esxl-!version!.zip' -Force"

if %errorlevel% neq 0 (
    echo 错误: 打包失败
    pause
    exit /b %errorlevel%
)

echo.
echo 正在检查Git状态...
git status --porcelain >nul 2>&1
if %errorlevel% equ 0 (
    echo 检测到未提交的更改，正在添加文件...
    git add .
    git commit -m "Release version !version!"
) else (
    echo 没有检测到未提交的更改
)

echo.
echo 正在创建Git标签...
git tag "v!version!" -m "Release version !version!"
git push origin master
git push origin "v!version!"

echo.
echo 发布完成!
echo 版本 !version! 已成功发布
echo 发布文件: %release_dir%\esxl-!version!.zip

echo.
echo 是否需要更新版本号？(y/n)
set /p update_version=
if /i "!update_version!"=="y" (
    echo 请输入新版本号 (当前版本: !version!):
    set /p new_version=
    if "!new_version!" neq "" (
        echo 更新版本号为 !new_version!
        powershell -Command "(gc app.config) -replace 'Version.*value=\"[0-9.]*\"', 'Version value=\"!new_version!\"' | sc app.config"
        git add app.config
        git commit -m "Update version to !new_version!"
        git push origin master
        echo 版本号已更新为 !new_version! 并推送到Gitee
    ) else (
        echo 未输入新版本号，跳过版本更新
    )
)

echo.
echo 发布脚本执行完成
pause