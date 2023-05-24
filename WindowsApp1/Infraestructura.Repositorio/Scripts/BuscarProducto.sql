declare @sqlquery varchar(max)
set @sqlquery=' where 1=1 '

IF (@id is not null and @id <>0)
 set @sqlquery = @sqlquery + ' AND ID = '''+  @id+''''
IF (@nombre <> NULL or @nombre <>'')
 set @sqlquery = @sqlquery + ' AND NOMBRE ='''+  @nombre+''''
IF (@precio is not null and @precio <>0)
 set @sqlquery = @sqlquery + ' AND PRECIO ='''+  @precio+''''
IF (@categoria <> null or @categoria <>'')
 set @sqlquery = @sqlquery + ' AND CATEGORIA ='''+  @categoria+''''

exec('select* from productos ' + @sqlquery)



 
