:: source: https://www.windows-commandline.com/find-large-files/

forfiles /S /M * /C "cmd /c if @fsize GEQ 52428800 echo @path"
pause