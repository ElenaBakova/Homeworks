#include <stdio.h>
#include <stdlib.h>

int main()
{
    int* block; 
    int n = 0;
    int m = 0;
    scanf("%d %d", &n, &m);
    n -= m;
    block = malloc((n) * sizeof(int));

    for (int i = 0;i < n; i++)
    {
        printf("block[%d]=", i);
        scanf("%d", &block[i]);
    }
    printf("\n");

    for (int i = 0;i < n; i++)
    {
        printf("%d \t", block[i]);
    }

    free(block);

    return 0;
}