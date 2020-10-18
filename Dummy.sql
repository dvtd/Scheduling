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


Delete from Employee
Delete from Exam


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
insert into Register(EmpID,ExamGroupID,Value,CreateTime) 
values 
(1,1,1,GETDATE()),
(1,2,2,GETDATE()),
(5,1,1,GETDATE()),
(5,2,2,GETDATE()),
(6,1,1,GETDATE()),
(6,2,2,GETDATE()),
(7,1,1,GETDATE()),
(7,2,2,GETDATE()),
(8,1,1,GETDATE()),
(8,2,2,GETDATE()),
(9,1,1,GETDATE()),
(9,2,2,GETDATE()),
(10,1,1,GETDATE()),
(10,3,2,GETDATE()),
(11,1,1,GETDATE()),
(11,3,2,GETDATE()),
(12,1,1,GETDATE()),
(12,3,2,GETDATE()),
(13,1,1,GETDATE()),
(13,4,1,GETDATE()),
(14,1,2,GETDATE()),
(14,4,2,GETDATE()),
(15,1,2,GETDATE()),
(15,4,1,GETDATE()),
(16,1,1,GETDATE()),
(16,4,1,GETDATE()),
(17,1,1,GETDATE()),
(17,4,1,GETDATE()),
(18,3,1,GETDATE()),
(18,4,2,GETDATE()),
(19,3,1,GETDATE()),
(19,4,2,GETDATE()),
(20,5,1,GETDATE()),
(20,4,2,GETDATE()),
(21,5,1,GETDATE()),
(21,4,2,GETDATE()),
(22,5,1,GETDATE()),
(22,4,2,GETDATE()),
(23,4,1,GETDATE()),
(23,5,2,GETDATE()),
(24,3,1,GETDATE()),
(24,5,2,GETDATE()),
(25,3,1,GETDATE()),
(25,5,2,GETDATE()),
(26,3,1,GETDATE()),
(26,1,2,GETDATE()),
(27,1,1,GETDATE()),
(27,4,2,GETDATE()),
(28,3,1,GETDATE()),
(28,5,2,GETDATE()),
(29,4,1,GETDATE()),
(29,2,2,GETDATE())

