DBCC CHECKIDENT (ExamSession, RESEED, 0)
DBCC CHECKIDENT (ExamCourse, RESEED, 0)
DBCC CHECKIDENT (WorkingTimeRequiredEmployee, RESEED, 0)
DBCC CHECKIDENT (WorkingTimeRequiredDepartment, RESEED, 0)
DBCC CHECKIDENT (Register, RESEED, 0)
DBCC CHECKIDENT (EmployeeRelated, RESEED, 0)

Delete from WorkingTimeRequiredDepartment
Delete from WorkingTimeRequiredEmployee
Delete from ExamCourse
Delete from EmployeeRelated
Delete from ExamSession
Delete from Register

select count(*) from ExamGroup EG join ExamSession ES on EG.ID = ES.ExamGroupID group by EG.ID

select count(*) from ExamGroup EG join Register RG on EG.ID = RG.ExamGroupID group by EG.ID
select * from ExamSession

Delete from Employee
Delete from Exam

select * from EmployeeDevice
insert into Employee(Username,Fullname,Phone,Email,Description,DepartmentID,RoleID,CreateTime,DelFlg)
values ('test18','test18' , '011111111' , 'test@fpt.edu.vn', 'ABC', '6' , '2', GETDATE(),0 ),
	('test19','test19' , '011111111' , 'test@fpt.edu.vn', 'ABC', '6' , '2', GETDATE(),0 ),
	('test20','test20' , '011111111' , 'test@fpt.edu.vn', 'ABC', '6' , '2', GETDATE(),0 ),
	('test21','test21' , '011111111' , 'test@fpt.edu.vn', 'ABC', '6' , '2', GETDATE(),0 )

insert into Room(RoomName,Description,RoomType) 
values ('A-111','ABC',0),
('A-111','ABC',0),
('A-112','ABC',0),
('A-113','ABC',0),
('A-114','ABC',0),
('A-115','ABC',0),
('A-116','ABC',0),
('A-117','ABC',0),
('A-118','ABC',0),
('A-119','ABC',0),
('A-120','ABC',0),
('A-121','ABC',0),
('A-122','ABC',0),
('A-123','ABC',0),
('A-124','ABC',0),
('A-125','ABC',0),
('A-126','ABC',0),
('A-127','ABC',0),
('A-128','ABC',0),
('A-129','ABC',0)

delete from Register
insert into Register(EmpID,ExamGroupID,Value,CreateTime,Status) 
values 
(2,1,1,GETDATE(),0),
(2,2,2,GETDATE(),0),
(5,1,1,GETDATE(),0),
(5,2,2,GETDATE(),0),
(6,1,1,GETDATE(),0),
(6,2,2,GETDATE(),0),
(7,1,1,GETDATE(),0),
(7,2,2,GETDATE(),0),
(8,1,1,GETDATE(),0),
(8,2,2,GETDATE(),0),
(9,1,1,GETDATE(),0),
(9,2,2,GETDATE(),0),
(10,1,1,GETDATE(),0),
(10,3,2,GETDATE(),0),
(11,1,1,GETDATE(),0),
(11,3,2,GETDATE(),0),
(12,1,1,GETDATE(),0),
(12,3,2,GETDATE(),0),
(13,1,1,GETDATE(),0),
(13,4,1,GETDATE(),0),
(14,1,2,GETDATE(),0),
(14,4,2,GETDATE(),0),
(15,1,2,GETDATE(),0),
(15,4,1,GETDATE(),0),
(16,1,1,GETDATE(),0),
(16,4,1,GETDATE(),0),
(17,1,1,GETDATE(),0),
(17,4,1,GETDATE(),0),
(18,3,1,GETDATE(),0),
(18,4,2,GETDATE(),0),
(19,3,1,GETDATE(),0),
(19,4,2,GETDATE(),0),
(20,5,1,GETDATE(),0),
(20,4,2,GETDATE(),0),
(21,5,1,GETDATE(),0),
(21,4,2,GETDATE(),0),
(22,5,1,GETDATE(),0),
(22,4,2,GETDATE(),0),
(23,4,1,GETDATE(),0),
(23,5,2,GETDATE(),0),
(24,3,1,GETDATE(),0),
(24,5,2,GETDATE(),0),
(25,3,1,GETDATE(),0),
(25,5,2,GETDATE(),0),
(26,3,1,GETDATE(),0),
(26,1,2,GETDATE(),0),
(27,1,1,GETDATE(),0),
(27,4,2,GETDATE(),0),
(28,3,1,GETDATE(),0),
(28,5,2,GETDATE(),0),
(29,4,1,GETDATE(),0),
(29,2,2,GETDATE(),0)

