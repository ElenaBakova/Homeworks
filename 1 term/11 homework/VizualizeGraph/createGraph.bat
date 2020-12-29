@echo off

cl /EHsc "Source.c"
start Source.exe
start dot -Tpng graph.dot -o graphImage.png
start graphImage.png