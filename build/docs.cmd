set folder="output/docs"
cd /d %folder%
for /F "delims=" %%i in ('dir /b') do (rmdir "%%i" /s/q || del "%%i" /s/q)
cd ../..
tools\Cake\Cake.exe build.cake -target="docsonly"