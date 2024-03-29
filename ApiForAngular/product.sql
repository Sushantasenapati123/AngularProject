USE [chikun]
GO
/****** Object:  Table [dbo].[product_tbl]    Script Date: 18-05-2023 17:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_tbl](
	[pid] [int] IDENTITY(1,1) NOT NULL,
	[pname] [varchar](20) NULL,
	[price] [numeric](6, 2) NULL,
	[pqty] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[product_tbl] ON 

INSERT [dbo].[product_tbl] ([pid], [pname], [price], [pqty]) VALUES (32, N'	Galaxy s7', CAST(555.00 AS Numeric(6, 2)), 5)
INSERT [dbo].[product_tbl] ([pid], [pname], [price], [pqty]) VALUES (33, N'Shyam', CAST(4.00 AS Numeric(6, 2)), 4)
INSERT [dbo].[product_tbl] ([pid], [pname], [price], [pqty]) VALUES (31, N'Gingerr', CAST(65.00 AS Numeric(6, 2)), 77)
INSERT [dbo].[product_tbl] ([pid], [pname], [price], [pqty]) VALUES (30, N'Sapuri', CAST(7.00 AS Numeric(6, 2)), 3)
SET IDENTITY_INSERT [dbo].[product_tbl] OFF
GO
/****** Object:  StoredProcedure [dbo].[op_product_tbl]    Script Date: 18-05-2023 17:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[op_product_tbl]
(@pid int=0,
@pname varchar(20)='',
@price numeric(6,2)=0.0,
@pqty int=0,

@action varchar(20)

)
as
begin

if(@action='D')
delete from  product_tbl where pid=@pid
else if(@action='A')
begin
  if(@pname!='')
     select * from  product_tbl  where pname like '%'+@pname+'%'
   else
   select * from  product_tbl


end

else if(@action='S')
select * from  product_tbl where pid=@pid
else if(@action='I')
insert into  product_tbl values(@pname,@price,@pqty)
else if(@action='U')
update product_tbl set pname=@pname,price=@price,pqty=@pqty where pid=@pid



end
GO
