# TP1_maitenance_logiciel
## Issue : Refactor fichiers
### Subissue : Page Principal, Teacher, Receptionnist
1.  Codesmell magic number
```c#
public Principal(int income = 50000)
{
     Income = income;
     Balance = 0;
}
```
Solution :
```c#
public Principal(int income = MembersSalary.PrincipalSalary)
{
     Income = income;
     Balance = 0;
}
```

