/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select 1 from dbo.Courses)
begin
INSERT INTO dbo.Courses (CourseId, [Name], [Description], Semester, PreRequisite, Compulsory, Credits, [Year]) VALUES
    ('D101','Programming Fundamentals'        , 'Learn the fundamentals of programming to develop quality software. During your studies you''ll develop an application using an industry standard language, and debug, test and document a software application.', 2, '',            1, 15, 1),
    ('D111','Database Fundamentals'           , 'Gain a broad operational knowledge of database design and administration. During your studies you''ll design a relational database to meet organisational requirements; apply interaction design concepts to a user interface; and store and retrieve organisational data using query and reporting tools.', 1, '',            1, 15, 1),
    ('I111','Web Fundamentals'                , 'Learn the fundamentals of web development and how to produce a quality website. You''ll employ UX design principles that meet organisational requirements and apply an industry standard approach.', 2, '',            1, 15, 1),
    ('I121','Systems Analysis Fundamentals'   , 'Learn the principles of systems analysis and systems requirements elicitation techniques. During your studies you''ll analyse situations requiring problem solving; elicit and model user requirements using a variety of techniques; and construct accurate systems analysis documentation reflecting requirements.', 1, '',            1, 15, 1),
    ('I101','Information Systems Fundamentals', 'Gain an understanding of business systems and essential components of the ICT profession.', 1, '',            1, 15, 1),
    ('I102','Technical Support Fundamentals'  , 'Learn how to deliver organisational technical support based on best practice in IT service management. During your studies you''ll apply a user needs analysis to identify organisational requirements; create, deliver and evaluate a training session; and develop technical documentation to a professional standard.', 2, '',            1, 15, 1),
    ('T101','Network Fundamentals'            , 'Learn the fundamentals of computer networks as they currently exist in industry, so that you can configure, test and troubleshoot local area networks.', 2, '',            1, 15, 1),
    ('T111','Computer Hardware Fundamentals'  , 'Gain an understanding of computer hardware, operating systems and troubleshooting techniques.', 1, '',            1, 15, 1),
    ('I202','IT Project Management'           , 'Gain an understanding of project management theory and practice as it relates to the ICT industry.', 2, 'I102',        1, 15, 2),
    ('I212','Enterprise Data Management'      , 'Learn to design and implement enterprise data management systems.', 1, 'I111',        0, 15, 2),
    ('D211','Database Development'            , 'Learn how to effectively design an information system for a complex business application.', 1, 'D111',        0, 15, 2),
    ('I213','Dynamic Web Solutions'           , 'Learn to create a dynamic web application utilising a variety of open-source technologies. During your studies you''ll design and document a web application; secure critical business data within the web application; interface with a web-based database management system; and implement user security and session management.', 2, 'I111',        0, 15, 2),
    ('I221','Analysis and Design'             , 'Create quality analysis and design documentation for a moderately complex system.', 2, 'I121',        0, 15, 2),
    ('T201','Network Services'                , 'Learn to implement key network services as used in modern LANs and to explain the network protocols that these services use. During your studies you''ll implement and explain the operation of name resolution; implement automatic network configuration; implement and explain the operation of directory services; implement and explain the operation of a web proxy; implement automatic browser configuration when a web proxy is used; implement file sharing; and implement and explain the operation of a basic firewall.', 1, 'T101',        0, 15, 2),
    ('D201','Advanced Programming'            , 'Learn standard algorithms required for business application programming. During your studies you''ll design and construct small applications using a variety of algorithms; devise test plans to ensure quality software; and create system maintenance documentation.', 1, 'D101',        0, 15, 2),
    ('D202','Software Process and Planning'   , 'Learn to create quality software applications utilising a modern development approach. During your studies you''ll work as a team on an iterative development project; manage an individual development task; implement processes to ensure quality; and compare and select an appropriate development method for a given problem.', 2, 'D101',        0, 15, 2),
    ('T206','Networks (CISCO RSE)'            , 'Gain practical and technical networking knowledge that will allow you to configure and troubleshoot routers, switches and resolve common issues with RIPv1, RIPng, single-area and multi-area OSPF, virtual LANs, and inter-VLAN routing in both IPv4 and IPv6 networks.', 1, 'T101',        0, 15, 2),
    ('I203','Digital Multimedia'              , 'Learn to apply principles and techniques relating to the application of digital multimedia technologies. During your studies you''ll learn about digital images, video and audio; create and manipulate digital image, video and audio files according to a technical specification for distribution across the ICT infrastructure; and optimise digital multimedia for commonly used ICT mediums.', 1, 'I101',        0, 15, 2),
    ('T211','Systems Security'                , 'Learn to analyse and implement computer systems security, including operating systems, server applications and networks; and explain the fundamentals of computer forensics.', 2, 'T111',        0, 15, 2),
    ('I301','Professional Practice'           , 'Prepare for transition into the ICT profession. Source an industry project and produce appropriate documentation.', 1, '240 Credits', 1, 15, 3),
    ('I321','Advanced Systems Analysis'       , 'Learn to introduce tools and techniques used to assess feasibility and present a business case; to complete an analysis of a complex information system based on the recommendation from the feasibility phase.', 1, 'I221',        0, 15, 3),
    ('I302','Industry Project'                , 'Undertake an industry-based project of a complex nature. During this experience you''ll manage an ICT project for industry; produce original work and project deliverables; consider and apply professional work ethics; meet project timelines and goals; record and evaluate project work and progress; and present project outcomes to sponsors and academic supervisors.', 2, 'I301',        1, 45, 3),
    ('T301','Network Design'                  , 'Learn how to recommend uses for thin and thick client architectures, and to design a thin client architecture.', 1, 'T201',        0, 15, 3),
    ('T302','CISCO Scaling and Connecting'    , 'Gain practical and technical networking knowledge that will assist in designing, building and analysing networks and their protocols using advanced technologies.', 1, 'T206',        0, 15, 3),
    ('D301','Software Engineering'            , 'Learn to design and construct quality software ready for distribution. During your studies you''ll perform object-oriented design and programming with a high level of proficiency; secure applications so that they are ready for distribution; conduct effective and efficient inspections; evaluate software user interfaces for accessibility and usability; and design and implement comprehenstive test plans.', 1, 'D201, D202',  0, 15, 3),
    ('T311','Systems Administration'          , 'Learn to design and construct a complex multi-user client/server network. You''ll gain skills needed to configure and integrate complex systems.', 1, 'T211',        0, 15, 3),
    ('D303','Mobile Application Development'  , 'Learn to develop mobile applications for current and emerging mobile computing devices.', 2, 'D101',        0, 15, 3),
    ('I304','Data Analytics and Intelligence' , 'Learn to use data analytics and business intelligence tools and techniques in order to provide decision support within an organisational context.', 2, 'D211, I212',  0, 15, 3),
    ('D311','Advanced Database Concepts'      , 'Learn to successfully design, create and administer a data warehouse using a server-based database management system.', 1, 'D211',        0, 15, 3),
    ('I311','Advanced Web Solutions'          , 'Learn to investigate, implement, and critique influentual, new, and emerging web technology solutions.', 1, 'I213',        0, 15, 3),
    ('I303','Managerial Practice'             , 'Learn to analyse and evaluate management practices as they relate to the ICT industry. During your studies you''ll discuss and analyse key issues associated with managing and structuring the ICT capability within an organisation; recommend and design a quality management programme for an organisation; apply best practice human resource management techniques; and commentate on the relevant legislation and social responsibility issues as they relate to the ICT industry.', 2, 'I202',        0, 15, 3),
    ('PM700','Advanced Project Management'     , 'Learn advanced principles of the project management body of knowledge and cover the content of the Project Management Institute and its application and evaluation to the workplace.', 1, '',            0, 15, 3),
    ('T312','Network Security (CCNA Security)', 'Learn to configure the components and operation of Virtual Private Networks, firewalls and network security.', 1, '',            0, 15, 3)
end

if not exists (select 1 from dbo.Majors)
begin
INSERT INTO dbo.Majors VALUES
('SE', 'Software Engineering'),
('BSA', 'Business and Systems Analysis'),
('SA', 'Systems Administration'),
('NE', 'Network Engineering'),
('WMD', 'Web and Mobile Development'),
('DMA', 'Data Management and Analytics'),
('PM', 'Project Management'),
('S', 'Security'),
('U', 'Undecided')
end

if not exists (select 1 from dbo.MajorCourses)
begin
INSERT INTO dbo.MajorCourses VALUES
('SE',  'D211'), 
('SE',  'D201'),
('SE',  'D202'),
('SE',  'D301'),
('SE',  'D303'),
('BSA', 'D211'),
('BSA', 'I221'),
('BSA', 'D202'),
('BSA', 'I321'),
('BSA', 'I303'),
('SA',  'T201'),
('SA',  'D211'),
('SA',  'T211'),
('SA',  'T311'),
('SA',  'D311'),
('SA',  'I303'),
('NE',  'T201'),
('NE',  'T206'),
('NE',  'T211'),
('NE',  'T301'),
('NE',  'T302'),
('WMD', 'D211'),
('WMD', 'I203'),
('WMD', 'I213'),
('WMD', 'I311'),
('WMD', 'D303'),
('DMA', 'I212'),
('DMA', 'D211'),
('DMA', 'D201'),
('DMA', 'D311'),
('DMA', 'I304'),
('PM',  'I212'),
('PM',  'D202'),
('PM',  'PM700'),
('PM',  'I303'),
('S',   'T201'),
('S',   'T206'),
('S',   'T211'),
('S',   'T311'),
('S',   'T312'),
('U',   'D211'), 
('U',   'D201'),
('U',   'D202'),
('U',   'D301'),
('U',   'D303'),
('U',   'I221'),
('U',   'I321'),
('U',   'I303'),
('U',   'T201'),
('U',   'T211'),
('U',   'T311'),
('U',   'D311'),  
('U',   'T206'), 
('U',   'T301'),
('U',   'T302'),
('U',   'I203'),
('U',   'I213'),
('U',   'I311'), 
('U',   'I212'), 
('U',   'I304'), 
('U',   'PM700'),   
('U',   'T312')
end

