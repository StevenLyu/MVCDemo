create Table [dbo].[Log4Net] (
[ID] [int] IDENTITY (1,1) Not null,
[date] [datetime] not null,
[thread][varchar](255) not null,
[level][varchar](10) not null,
[Logger][varchar](1000) not null,
[Message][varchar](4000) not null,
[Exception][varchar](4000) not null
) on [Primary]