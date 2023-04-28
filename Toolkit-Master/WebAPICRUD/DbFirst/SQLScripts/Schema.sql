create procedure usp_getproduct
@ProductId int
as
begin
	Select * from Products where ProductId=@ProductId
end

