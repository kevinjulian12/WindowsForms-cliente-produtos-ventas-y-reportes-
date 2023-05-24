declare @sqlquery varchar(max)

set @sqlquery=' where 1=1 '

IF (@id is not null and @id <>0)
 set @sqlquery = @sqlquery + ' AND ID = '''+  @id+''''

IF @cliente is not null and @cliente<>''
 set @sqlquery = @sqlquery + ' AND CLIENTE ='''+  @cliente+''''

IF (@telefono <> null or @telefono <>'')
 set @sqlquery = @sqlquery + ' AND TELEFONO ='''+  @telefono+''''

IF (@correo <> null or @correo <>'')
 set @sqlquery = @sqlquery + ' AND CORREO ='''+  @correo+''''

exec('select* from clientes ' + @sqlquery)



 
