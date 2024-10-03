CREATE TABLE bienesoft.learner (
    Id_Learner INT AUTO_INCREMENT PRIMARY KEY,
    Learner_Name VARCHAR(100) NOT NULL,
    Learner_Phone VARCHAR(15),
    Learner_Type VARCHAR(50),
    Session_Count INT,
    JWT_Token INT
);
INSERT INTO bienesoft.learner (Learner_Name, Learner_Phone, Learner_Type, Session_Count, JWT_Token)
VALUES ('Argeol Guio', '3245876760', "BUENO", 0,2 );
departmentCREATE TABLE bienesoft.department(
    Id_Department INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL
);
INSERT INTO  bienesoft.department (DepartmentName)
VALUES ('Tolima');

