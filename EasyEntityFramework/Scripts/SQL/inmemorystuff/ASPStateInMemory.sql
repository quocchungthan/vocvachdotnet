-- https://cloudblogs.microsoft.com/sqlserver/2014/07/10/new-asp-net-session-state-provider-for-sql-server-in-memory-oltp/

-- same name in web.config file
CREATE DATABASE [ASPStateInMemory]
ON PRIMARY (
  NAME = ASPStateInMemory, FILENAME = 'D:\data\ASPStateInMemory_data.mdf'
),
FILEGROUP ASPStateInMemory_xtp_fg CONTAINS MEMORY_OPTIMIZED_DATA (
  NAME = ASPStateInMemory_xtp, FILENAME = 'D:\data\ASPStateInMemory_xtp'
)
GO