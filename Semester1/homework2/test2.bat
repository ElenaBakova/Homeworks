@echo off
for /r C:\Users\lenab\Desktop\HW\Homeworks\1term\2homework\ %%B in (*.c) do (
	cl /EHsc %%B
	echo %%B
	if %ERRORLEVEL% equ 0 (
		echo ______Tests succeed_______
	) else (
		echo ______Tests failed_______
	)
)
pause