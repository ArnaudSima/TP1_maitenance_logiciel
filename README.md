#TP1_maitenance_logiciel

1.Codesmell magic number
```c#
public Principal(int income = 50000)
{
     Income = income;
     Balance = 0;
}
```
aaa,
Solution :
aaa
```c#
public Principal(int income = MembersSalary.PrincipalSalary)
{
     Income = income;
     Balance = 0;
}
```

