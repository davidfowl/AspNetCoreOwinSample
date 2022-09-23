# ASP.NET Core with OWIN

This sample shows how to "lift and shift" ASP.NET Web API to run on top of ASP.NET Core using the OWIN bridge. 

- `/` - Will match the route declared at the top level
- `/api/products` - Will match the ASP.NET Web API controller
- `/api/products2` - Will match the ASP.NET Core controller

The project references:

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.AspNet.WebApi.Core" Version="5.2.9">
       <NoWarn>NU1701</NoWarn>
    </PackageReference>
    <PackageReference Include="Microsoft.AspNet.WebApi.Owin" Version="5.2.9">
       <NoWarn>NU1701</NoWarn>
    </PackageReference>
    <PackageReference Include="Microsoft.Owin" Version="4.2.2">
       <NoWarn>NU1701</NoWarn>
    </PackageReference>
    <PackageReference Include="Owin" Version="1.0.0">
       <NoWarn>NU1701</NoWarn>
    </PackageReference>
</ItemGroup>
```

These packages are *NOT* recompiled to target .NET 6 but they are compatible. The following warnings will show up on build:

```
Warning	NU1701	Package 'Microsoft.AspNet.WebApi.Core 5.2.9' was restored using '.NETFramework,Version=v4.6.1, .NETFramework,Version=v4.6.2, .NETFramework,Version=v4.7, .NETFramework,Version=v4.7.1, .NETFramework,Version=v4.7.2, .NETFramework,Version=v4.8, .NETFramework,Version=v4.8.1' instead of the project target framework 'net6.0'. This package may not be fully compatible with your project.
Warning	NU1701	Package 'Microsoft.AspNet.WebApi.Owin 5.2.9' was restored using '.NETFramework,Version=v4.6.1, .NETFramework,Version=v4.6.2, .NETFramework,Version=v4.7, .NETFramework,Version=v4.7.1, .NETFramework,Version=v4.7.2, .NETFramework,Version=v4.8, .NETFramework,Version=v4.8.1' instead of the project target framework 'net6.0'. This package may not be fully compatible with your project.
Warning	NU1701	Package 'Microsoft.Owin 4.2.2' was restored using '.NETFramework,Version=v4.6.1, .NETFramework,Version=v4.6.2, .NETFramework,Version=v4.7, .NETFramework,Version=v4.7.1, .NETFramework,Version=v4.7.2, .NETFramework,Version=v4.8, .NETFramework,Version=v4.8.1' instead of the project target framework 'net6.0'. This package may not be fully compatible with your project.
Warning	NU1701	Package 'Owin 1.0.0' was restored using '.NETFramework,Version=v4.6.1, .NETFramework,Version=v4.6.2, .NETFramework,Version=v4.7, .NETFramework,Version=v4.7.1, .NETFramework,Version=v4.7.2, .NETFramework,Version=v4.8, .NETFramework,Version=v4.8.1' instead of the project target framework 'net6.0'. This package may not be fully compatible with your project.
```

These are ok to suppress for these particular packages.