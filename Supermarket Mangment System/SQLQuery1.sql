select * from SMan_IO

Select RIGHT(CONVERT(VARCHAR, GETDATE(), 100),7)
insert into SMan_IO values (2,GETDATE(),'8:02:50',CAST(GETDATE() as TIME))

select io.Date,io.Id,io.Out 
from SMan_IO as io join Employee as emp
on io.ID = emp.Id

