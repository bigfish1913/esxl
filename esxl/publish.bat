@echo off
setlocal enabledelayedexpansion
echo 正在发布到Gitee...

REM 获取当前目录
set "SCRIPT_DIR=%~dp0"
set "ROOT_DIR=%SCRIPT_DIR%"
set "CONFIG_FILE=%SCRIPT_DIR%app.config"

REM 检查app.config文件是否存在
if not exist "%CONFIG_FILE%" (
    echo 错误: 找不到配置文件 %CONFIG_FILE%
    pause
    exit /b 1
)

REM 从app.config文件中提取版本号
set "VERSION=1.0.0"
for /f "tokens=*" %%A in ('findstr "key=.Version." "%CONFIG_FILE%"') do (
    set "line=%%A"
    echo !line! | findstr "key=.Version." >nul
    if not errorlevel 1 (
        for /f "tokens=2 delims==" %%B in ("!line!") do (
            set "temp_version=%%B"
            REM 清理版本号字符串（移除空格和引号以及/>等字符）
            set "temp_version=!temp_version: =!"
            set "temp_version=!temp_version:"=!"
            set "temp_version=!temp_version:/>=!"
            set "temp_version=!temp_version:/=>!"
            for /f "delims=>" %%C in ("!temp_version!") do (
                set "clean_version=%%C"
                if "!clean_version!" neq "" (
                    set "VERSION=!clean_version!"
                )
            )
        )
    )
)

echo 当前版本: v%VERSION%

REM 分解版本号
for /f "tokens=1,2,3 delims=." %%a in ("%VERSION%") do (
    set "MAJOR=%%a"
    set "MINOR=%%b"
    set "BUILD=%%c"
)

REM 增加构建版本号
set /a BUILD+=1
set "NEW_VERSION=%MAJOR%.%MINOR%.%BUILD%"

echo 新版本: v%NEW_VERSION%

REM 编译Release版本
echo 正在编译Release版本...
cd /d "%ROOT_DIR%"
dotnet publish -c Release -o "publish" --self-contained -r win-x64
if errorlevel 1 (
    echo 编译失败，退出发布流程
    pause
    exit /b 1
)

REM 打包Release版本
echo 正在打包Release版本...
cd /d "%ROOT_DIR%"
if exist "release.zip" del "release.zip"
powershell -Command "Compress-Archive -Path 'publish/*' -DestinationPath 'release.zip' -Force"
if errorlevel 1 (
    echo 打包失败，退出发布流程
    pause
    exit /b 1
)

REM 添加所有更改
git add .

REM 获取当前时间作为提交信息
for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "YY=%dt:~2,2%" & set "YYYY=%dt:~0,4%" & set "MM=%dt:~4,2%" & set "DD=%dt:~6,2%"
set "HH=%dt:~8,2%" & set "Min=%dt:~10,2%" & set "Sec=%dt:~12,2%"
set "datestamp=%YYYY%-%MM%-%DD% %HH%:%Min%:%Sec%"

REM 提交更改
git commit -m "Auto publish update %datestamp%"

REM 创建带版本号的标签
git tag -a "v%NEW_VERSION%" -m "Release version %NEW_VERSION%"

REM 更新app.config中的版本号
if exist "%CONFIG_FILE%.tmp" del "%CONFIG_FILE%.tmp"
for /f "delims=" %%i in ('type "%CONFIG_FILE%"') do (
    set "line=%%i"
    echo !line! | findstr "key=.Version." >nul
    if not errorlevel 1 (
        echo !line:%VERSION%=%NEW_VERSION%! >> "%CONFIG_FILE%.tmp"
    ) else (
        echo !line! >> "%CONFIG_FILE%.tmp"
    )
)
move /y "%CONFIG_FILE%.tmp" "%CONFIG_FILE%"

REM 推送所有更改和标签到Gitee
git push origin master
git push origin --tags

echo 发布完成! 版本: v%NEW_VERSION%
pause