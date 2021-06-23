create database ZhongxiaoMeiClientInformationSystem
go

use ZhongxiaoMeiClientInformationSystem
go

/*
	insert some sample data into Clients table
	data generated using www.generatedata.com 
*/
INSERT INTO Clients([Name],[Email],[Phones],[Address],[AddedOn]) VALUES('Oren','tincidunt@consectetuercursus.co.uk','1-406-117-9190','Ap #421-9747 Sed Av.','03/17/2021'),('Richard','pede@eumetus.edu','1-597-935-3926','Ap #170-4729 Nullam St.','09/27/2021'),('Russell','sapien@musProin.net','1-288-215-4734','P.O. Box 358, 1089 Ullamcorper St.','07/14/2021'),('Colt','massa@varius.com','1-273-513-2235','P.O. Box 581, 1110 Vel, Av.','06/01/2022'),('Duncan','velit@diam.edu','1-705-152-2449','501-928 A Avenue','10/28/2020'),('Colton','ornare.facilisis@utdolordapibus.edu','1-478-612-6937','210-7864 Volutpat. Street','10/29/2021'),('Aaron','lacus.Cras@sitamet.com','1-678-366-0369','4704 Torquent Road','10/17/2020'),('Carter','In@risus.co.uk','1-401-771-7944','352-4980 Sodales St.','10/08/2020'),('Omar','dolor@eleifend.edu','1-482-541-3957','549-9392 Id, Ave','05/15/2021'),('Trevor','mollis.Phasellus@eleifendvitae.ca','1-458-947-7295','116-3742 Aliquam Avenue','01/16/2022');
INSERT INTO Clients([Name],[Email],[Phones],[Address],[AddedOn]) VALUES('Grant','ligula.consectetuer@ut.org','1-348-676-6331','P.O. Box 577, 3946 Mattis Rd.','11/04/2020'),('Dolan','vel.mauris@ultricessit.org','1-650-122-5817','P.O. Box 686, 4006 Arcu. Av.','02/13/2022'),('Solomon','imperdiet@gravida.com','1-283-807-0789','P.O. Box 722, 4466 Sagittis Road','09/17/2021'),('Dorian','placerat.Cras@ornare.com','1-683-317-0929','P.O. Box 643, 6613 Odio. Street','06/29/2020'),('Alexander','penatibus.et.magnis@euultrices.org','1-234-698-0588','P.O. Box 589, 4486 Erat St.','03/05/2021'),('Amir','arcu.Aliquam.ultrices@ac.com','1-798-323-5953','929-9825 Integer Street','09/01/2020'),('Kirk','magna@commodo.org','1-818-845-9399','P.O. Box 300, 2527 Cras Rd.','04/30/2022'),('Carl','malesuada@purusNullam.ca','1-677-729-6361','P.O. Box 178, 1910 Amet Av.','05/10/2022'),('Ivor','viverra@risus.ca','1-951-878-5331','854-8621 Sed Avenue','03/12/2021'),('Bradley','luctus.felis@arcuMorbi.ca','1-237-319-1941','869-9493 Nisi Road','08/29/2021');


/*
	insert some sample data into Employees table
	data generated using www.generatedata.com 
*/
INSERT INTO Employees([Name],[Password],[Designation]) VALUES('Lane','TT243TI2','Human Resources'),('Leilani','JS822CL1','Accounting'),('Beatrice','WA312DW2','Advertising'),('Rowan','XR819IU6','Quality Assurance'),('Brady','OG815XB1','Customer Service'),('Colton','SM750PP5','Customer Service'),('Uriel','DJ605ZS7','Finances'),('Alexa','LX257KO8','Quality Assurance'),('Aretha','VG721IM2','Asset Management'),('Destiny','MH518EZ5','Advertising');
INSERT INTO Employees([Name],[Password],[Designation]) VALUES('Candace','KQ560GZ2','Asset Management'),('Quinn','SD480SK2','Quality Assurance'),('Macon','NS193LR2','Media Relations'),('Abra','GM949WE3','Customer Relations'),('Lunea','KO232EB3','Finances'),('Kellie','BZ542EN3','Research and Development'),('Ira','VD744FE2','Legal Department'),('Daquan','NL387VN9','Legal Department'),('Kimberley','EZ958SL8','Payroll'),('Kirestin','BB720UR2','Asset Management');

/*
	insert some sample data into Interactions table
	data generated using www.generatedata.com
*/
INSERT INTO Interactions([ClientId],[EmpId],[IntType],[IntDate],[Remarks]) VALUES(204,2,'T','04/20/2021',''),(207,12,'W','06/08/2021',''),(210,7,'T','09/20/2021','Need more time'),(205,7,'W','05/18/2022','Very Important, 4 People'),(215,5,'S','01/06/2021','To be continued'),(213,11,'W','01/05/2022','Need more time'),(216,11,'S','10/04/2021','To be continued'),(218,14,'S','02/09/2022','To be continued, Very Important'),(218,19,'T','06/25/2020','4 People'),(217,1,'T','03/20/2020','4 People, To be continued');
INSERT INTO Interactions([ClientId],[EmpId],[IntType],[IntDate],[Remarks]) VALUES(220,16,'W','12/09/2020','To be continued, Need more time'),(210,2,'W','02/14/2022',''),(208,7,'T','09/26/2020','Very Important'),(217,4,'W','10/12/2020','4 People'),(219,14,'T','06/14/2021','4 People, To be continued'),(208,2,'S','06/13/2021','4 People, To be continued'),(216,5,'I','10/22/2021','To be continued'),(218,4,'W','04/15/2022','Very Important'),(220,3,'W','10/11/2021',''),(214,7,'I','06/19/2020','4 People');