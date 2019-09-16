<p align="right">
  <a href="./README.md">English</a> |  
  <span>中文</a>
</p>
<h1 align="center">NCaptcha
    <sup style="font-size:10px;">.NET Core 验证码组件库</sup>
</h1>

[![Build Status](https://dev.azure.com/elderjames/NCaptcha-Pipelines/_apis/build/status/ElderJames.NCaptcha?branchName=master)](https://dev.azure.com/elderjames/NCaptcha-Pipelines/_build/latest?definitionId=1&branchName=master)

## 什么是 NCaptcha?

NCaptcha 是面向 .NET Core 的组件化的验证码集成方案，基于.NET Standard 2.0，并且非常易于扩展。

它通过许多开箱即用的解决方案帮助您实现基于验证码的安全机制，也可以让您非常方便地集成您自己的实现。因为它的实现是组件化的，允许您方便地实现需要修改或替换的部分。

NCaptcha 中的组件分为“生成器”、“验证器”、“目标实现” 和“状态维持”四部分。目前为止，已经实现了基于 Session 的图片、邮件和短信方案。

## Nuget 包

| Package                                                                                                | NuGet Stable                                                                                                                                                                    | Downloads                                                                                                                                                                        |
| ------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [NCaptcha](https://www.nuget.org/packages/NCaptcha/)                                                   | [![NCaptcha](https://img.shields.io/nuget/v/NCaptcha.svg)](https://www.nuget.org/packages/NCaptcha/)                                                                            | [![NCaptcha](https://img.shields.io/nuget/dt/NCaptcha.svg)](https://www.nuget.org/packages/NCaptcha/)                                                                            |
| [NCaptcha.State.Session](https://www.nuget.org/packages/NCaptcha.State.Session/)                       | [![NCaptcha.State.Session](https://img.shields.io/nuget/v/NCaptcha.State.Session.svg)](https://www.nuget.org/packages/NCaptcha.State.Session/)                                  | [![NCaptcha.State.Session](https://img.shields.io/nuget/dt/NCaptcha.State.Session.svg)](https://www.nuget.org/packages/NCaptcha.State.Session/)                                  |
| [NCaptcha.Targets.Images](https://www.nuget.org/packages/NCaptcha.Targets.Images/)                     | [![NCaptcha.Targets.Images](https://img.shields.io/nuget/v/NCaptcha.Targets.Images.svg)](https://www.nuget.org/packages/NCaptcha.Targets.Images/)                               | [![NCaptcha.Targets.Images](https://img.shields.io/nuget/dt/NCaptcha.Targets.Images.svg)](https://www.nuget.org/packages/NCaptcha.Targets.Images/)                               |
| [NCaptcha.Targets.Email](https://www.nuget.org/packages/NCaptcha.Targets.Email/)                       | [![NCaptcha.Targets.Email](https://img.shields.io/nuget/v/NCaptcha.Targets.Email.svg)](https://www.nuget.org/packages/NCaptcha.Targets.Email/)                                  | [![NCaptcha.Targets.Email](https://img.shields.io/nuget/dt/NCaptcha.Targets.Email.svg)](https://www.nuget.org/packages/NCaptcha.Targets.Email/)                                  |
| [NCaptcha.Targets.Sms](https://www.nuget.org/packages/NCaptcha.Targets.Sms/)                           | [![NCaptcha.Targets.Sms](https://img.shields.io/nuget/v/NCaptcha.Targets.Sms.svg)](https://www.nuget.org/packages/NCaptcha.Targets.Sms/)                                        | [![NCaptcha.Targets.Sms](https://img.shields.io/nuget/dt/NCaptcha.Targets.Sms.svg)](https://www.nuget.org/packages/NCaptcha.Targets.Sms/)                                        |
| [NCaptcha.Targets.Sms.Aliyun](https://www.nuget.org/packages/NCaptcha.Targets.Sms.Aliyun/)             | [![NCaptcha.Targets.Sms.Aliyun](https://img.shields.io/nuget/v/NCaptcha.Targets.Sms.Aliyun.svg)](https://www.nuget.org/packages/NCaptcha.Targets.Sms.Aliyun/)                   | [![NCaptcha.Targets.Sms.Aliyun](https://img.shields.io/nuget/dt/NCaptcha.Targets.Sms.Aliyun.svg)](https://www.nuget.org/packages/NCaptcha.Targets.Sms.Aliyun/)                   |
| [NCaptcha.AspNetCore](https://www.nuget.org/packages/NCaptcha.AspNetCore/)                             | [![NCaptcha.AspNetCore](https://img.shields.io/nuget/v/NCaptcha.AspNetCore.svg)](https://www.nuget.org/packages/NCaptcha.AspNetCore/)                                           | [![NCaptcha.AspNetCore](https://img.shields.io/nuget/dt/NCaptcha.AspNetCore.svg)](https://www.nuget.org/packages/NCaptcha.AspNetCore/)                                           |
| [NCaptcha.AspNetCore.SessionImages](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionImages/) | [![NCaptcha.AspNetCore.SessionImages](https://img.shields.io/nuget/v/NCaptcha.AspNetCore.SessionImages.svg)](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionImages/) | [![NCaptcha.AspNetCore.SessionImages](https://img.shields.io/nuget/dt/NCaptcha.AspNetCore.SessionImages.svg)](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionImages/) |
| [NCaptcha.AspNetCore.SessionEmail](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionEmail/)   | [![NCaptcha.AspNetCore.SessionEmail](https://img.shields.io/nuget/v/NCaptcha.AspNetCore.SessionEmail.svg)](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionEmail/)    | [![NCaptcha.AspNetCore.SessionEmail](https://img.shields.io/nuget/dt/NCaptcha.AspNetCore.SessionEmail.svg)](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionEmail/)    |
| [NCaptcha.AspNetCore.SessionSms](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionSms/)       | [![NCaptcha.AspNetCore.SessionSms](https://img.shields.io/nuget/v/NCaptcha.AspNetCore.SessionSms.svg)](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionSms/)          | [![NCaptcha.AspNetCore.SessionSms](https://img.shields.io/nuget/dt/NCaptcha.AspNetCore.SessionSms.svg)](https://www.nuget.org/packages/NCaptcha.AspNetCore.SessionSms/)          |

## 使用方法

### 使用开箱即用方案

-   [基于 Session 的图片验证码](./docs/cn/session-image.md)
-   [基于 Session 的邮件验证码](./docs/cn/session-email.md)
-   [基于 Session 的短信验证码](./docs/cn/session-sms.md)

    目前已实现以下短信服务商：

    -   阿里云
