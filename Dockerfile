FROM mcr.microsoft.com/mssql/seerver:2019-latest

ENV ACCEPT_EULA=V
ENV MSSQL_PID=Developer

ENV MSQL_SA_PASSWORD=1234

EXPOSE 1433