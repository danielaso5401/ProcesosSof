-- 1 procedure se aumenta el precio de los productos segun su codigo y el aumento indicado
create or replace procedure aumento_precio_producto(n_id in number, n_aumento in number)
is
begin
update productos set precio_unit=precio_unit+n_aumento where idproductos=n_id;
end;
exec aumento_precio_producto(1,-4);
select * from productos;

-- 2 ingresa nueva categorias pero verifica que no se repita la categoria
create or replace procedure agregar_cateogira(n_idcat in number, n_categoriag in categorias.nom_cat%type)
is
cursor c1 is 
select idcategoria, nom_cat from categorias where nom_cat=n_categoriag;
n_cont number :=0;
cat_exis exception;
begin
    for i in c1 loop
        n_cont:=n_cont+1;
    end loop;
    if n_cont<>0 then
        raise cat_exis;
    end if;
    insert into categorias (idcategoria,nom_cat) values(n_idcat,n_categoriag);
    exception
    when cat_exis then
    	dbms_output.put_line('la categoria '|| n_categoriag || ' ya existe en la base de datos' );
end;

exec agregar_cateogira(4,'Embutidos');

select * from categorias;

-- 3 otorga un asenso al empleado
create or replace procedure ascenso(n_id in number, v_aumento in varchar2)
is
validar_puesto exception;
begin
select cargo from empleado;

update empleado set cargo=v_aumento where idempleado=n_id  and cargo<>v_aumento;

end;
exec ascenso(2,'Gerente')
select * from empleado;

--4

create or replace procedure most_client(c_cursor out sys_refcursor)
is
begin
open c_cursor for
select * from cliente;
end;


declare 
l_cursor SYS_REFCURSOR := NULL;
l_idclie cliente.idcliente%type;
l_nombre cliente.nom_comp%type;
l_direc cliente.direccion%type;
l_cel cliente.celular%type;
l_email cliente.email%type;

begin
most_client(l_cursor);

loop 
    fetch l_cursor
    into l_idclie, l_nombre, l_direc, l_cel, l_email;
    exit when l_cursor%notfound;
    DBMS_OUTPUT.PUT_LINE(l_idclie || '|' || l_nombre || '|' || l_direc || '|' || l_cel ||  '|' || l_email);
end loop;
close l_cursor;
end;
    
    
    
    
create or replace procedure delete_client(n_id in cliente.idcliente%type)
is
begin

delete cliente where cliente.idcliente=n_id;
commit;
end;



create or replace procedure update_cliente(n_id in number, c_name in varchar2, c_direc in varchar, n_celular in number, c_emal in VARCHAR2)
is

begin

update cliente set nom_comp=c_name, direccion=c_direc, celular=n_celular, email=c_emal where idcliente=n_id;

end;

create or replace procedure insert_cliente(n_id in number, c_name in varchar2, c_direc in varchar, n_celular in number, c_emal in VARCHAR2)
is

begin

insert into cliente (idcliente, nom_comp, direccion, celular, email) values (n_id, c_name, c_direc, n_celular, c_emal);

end;

exec update_cliente(3,'prueba5','prueba2',12345,'prueba2@gmail.com');
exec insert_cliente(4,'prueba2','prueba2',12345,'prueba2@gmail.com');

select * from cliente;

--mostrar prodcutos

create or replace procedure most_productos(c_cursor out sys_refcursor)
is
begin
open c_cursor for
select p.idproductos, p.nom_prod, p.cantidad ,p.precio_unit, p.idproveedor ,r.nom_comp, p.idcategoria, c.nom_cat 
from productos P, categorias C, proveedor R 
where p.idproveedor=r.idproveedor and P.idcategoria=c.idcategoria;
end;

-- eliminar productos
create or replace procedure delete_prod(n_id in productos.idproductos%type)
is
begin
delete productos where productos.idproductos=n_id;
commit;
end;

-- actualizar productos
create or replace procedure update_produc
(n_id in number,
c_name in varchar2,
n_cant in number,
f_pri in float,
n_prov in number,
n_cat in number)
is
begin
update productos set nom_prod=c_name, cantidad=n_cant,precio_unit=f_pri, idproveedor=n_prov,idcategoria=n_cat 
where idproductos=n_id;
end;
exec update_produc(3,'manzana',22,5.120,2,3);

-- insertar productos
create sequence demo_client
START WITH 5
INCREMENT by 1
MAXVALUE 105
cycle;

create or replace procedure insert_produc
(c_name in varchar2,
n_cant in number,
f_pri in float,
n_prov in number,
n_cat in number)
is
begin
insert into productos(idproductos,nom_prod,cantidad,precio_unit,idproveedor,idcategoria) values (DEMO_CLIENT.nextval,c_name,n_cant,f_pri,n_prov,n_cat);
end;

-- login
create or replace procedure login_usu(c_usuario in varchar2, c_contra in varchar2, n_resp out number)
is
c_valcorr empleado.correo%TYPE;
c_valcontra empleado.contrase%type;
begin
select correo, contrase into c_valcorr, c_valcontra from empleado where  correo=c_usuario and contrase=c_contra;
n_resp :=1;
exception
when no_data_found then n_resp :=0;
end;

declare
n_number number;
begin
login_usu('juan@gmail.com','54321',n_number);
dbms_output.put_line(n_number);
end;
