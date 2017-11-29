cls
call env.cmd
powershell -Command "& { Set-ExecutionPolicy RemoteSigned; Invoke-Expression %~dp0build.ps1; } "
