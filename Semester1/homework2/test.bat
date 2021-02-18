@echo off
for %%B in ("C:\Users\lenab\Desktop\HW\Homeworks\1term\2homework\Bubble-and-count-sort\*.c" "C:\Users\lenab\Desktop\HW\Homeworks\1term\2homework\Exponentiation\*.c" "C:\Users\lenab\Desktop\HW\Homeworks\1term\2homework\Fibonacci\*.c" "C:\Users\lenab\Desktop\HW\Homeworks\1term\2homework\FourthProblem\*.c") do (
	cl /EHsc %%B
	echo %%B
	if %ERRORLEVEL% equ 0 (
		echo ______Tests succeed_______
	) else (
		echo ______Tests failed_______
	)
)
pause