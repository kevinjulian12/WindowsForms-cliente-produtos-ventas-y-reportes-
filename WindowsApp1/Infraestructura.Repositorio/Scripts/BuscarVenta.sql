declare @sqlquery varchar(max)

set @sqlquery=' where 1=1 '

IF (@id is not null and @id <>0)
 set @sqlquery = @sqlquery + ' AND ID = '''+  @id+''''

IF @idcliente is not null and @idcliente<>''
 set @sqlquery = @sqlquery + ' AND IDCLIENTE ='''+  @idcliente+''''

IF (@fecha <> null or @fecha <>'')
  set @sqlquery = @sqlquery + ' AND FORMAT(FECHA,''yyyy-MM-dd'') ='''+  @fecha+''''

exec('select* from ventas ' + @sqlquery)

