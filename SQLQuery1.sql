select * from ventasitems
  join productos
  on IDProducto=productos.ID;

  select * from ventasitems
  join ventas
  on IDVenta=ventas.ID;
   
   insert into ventas values (2,'12/02/2018',95);
    insert into ventas values (2,'02/04/2019',56);
	 insert into ventas values (2,'19/09/2020',73);

   select* from ventas
join clientes
on IDCliente=clientes.ID;

insert into ventasitems values (1,1,100,2,50*2);
insert into ventasitems values (1,1,100,2,60*2);
insert into ventasitems values (1,1,100,2,60*2);
insert into ventasitems values (1,1,100,2,60*2);

select* from ventas
where IDCliente=2;

select* from ventasitems
where IDVenta=1

select* from ventasitems
join productos
on IDProducto=productos.ID
where IDVenta=1

select* from ventas
join clientes
on IDCliente=clientes.ID
where IDCliente=5;

select Categoria from productos

select Nombre from productos
where Categoria='Informatica'

select Cliente,Telefono,Correo,Nombre,Categoria,Precio,Cantidad,PrecioTotal 
from ventasitems
inner join ventas v on IDVenta = v.ID 
inner join clientes c on IDCliente = c.ID
inner join productos p on IDProducto = p.ID 

select Nombre, sum(Cantidad) as Cantidad
from ventasitems
inner join productos p on IDProducto = p.ID 
inner join ventas v on IDVenta = v.ID 
where month(v.Fecha) =2
group by Nombre

select Nombre,Categoria,Cantidad 
from ventasitems
inner join productos p on IDProducto = p.ID 
inner join ventas v on IDVenta = v.ID 