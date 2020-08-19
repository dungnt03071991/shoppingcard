declare @productId int   
select @productId = 1  
declare @ProductName varchar(100) 
while @productId >=1 and @productId <= 100000
begin  
set @ProductName = 'item '+ CAST(@productId as nvarchar(10)) 
 insert into items(Name)   
                values( @ProductName)  
    select @productId = @productId + 1  
end  