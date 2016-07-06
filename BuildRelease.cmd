echo Cleanup Release folder ...
del Release\*.*  /s /q


call CopyExternal.cmd

call BuildService.cmd

call BuildViewer.cmd

echo finished!
pause