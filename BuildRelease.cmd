echo Cleanup Release folder ...
del _Release\*.*  /s /q


call CopyExternal.cmd

call BuildService.cmd

call BuildViewer.cmd

echo finished!
pause