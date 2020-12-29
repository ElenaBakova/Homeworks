@echo off

cl /EHsc "Source.c"
start Source.exe
start dot -Tpng graph.dot -o graphImage.png
TIMEOUT /T 2
start graphImage.png