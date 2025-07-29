@echo off
setlocal enabledelayedexpansion

echo 正在提取版本号...
for /f "tokens=2 delims=value=" %%a in ('findstr /r "Version.*value" app.config') do (
    for /f "tokens=1 delims= " %%b in ("%%a") do (
        set "version=%%~b"
        goto :found_version
    )
)

:found_version
if "%version%"=="" (
    echo 无法从app.config中提取版本号
    pause
    exit /b 1
)

echo 当前版本号: %version%

echo 正在以Release模式编译项目...
dotnet publish -c Release -o ./publish

if %errorlevel% neq 0 (
    echo 编译失败
    pause
    exit /b %errorlevel%
)

echo 正在创建版本发布...
echo 正在推送代码到Gitee...
git add .
git commit -m "Release version %version%"
git push origin master

echo 创建版本发布需要手动操作，请到Gitee页面创建新版本:
echo 1. 访问项目页面
echo 2. 点击"发布"标签
echo 3. 点击"创建发布"
echo 4. 版本号填写: %version%
echo 5. 上传publish目录中的文件作为附件

echo 版本发布完成后，是否需要更新版本号？(y/n)
set /p update_version=
if /i "%update_version%"=="y" (
    echo 请输入新版本号 (当前版本: %version%):
    set /p new_version=
    if "!new_version!" neq "" (
        echo 更新版本号为 !new_version!
        powershell -Command "(gc app.config) -replace 'Version.*value=\"[0-9.]*\"', 'Version value=\"!new_version!\"' | sc app.config"
        git add app.config
        git commit -m "Update version to !new_version!"
        git push origin master
        echo 版本号已更新为 !new_version! 并推送到Gitee
    )
)

echo 发布脚本执行完成
pause