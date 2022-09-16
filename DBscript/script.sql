USE projecttasks;

CREATE TABLE TaskType (
    Id int NOT NULL AUTO_INCREMENT,
    Name varchar(255) NOT NULL,

    PRIMARY KEY (Id)
); 


CREATE TABLE Task (
    Id int NOT NULL AUTO_INCREMENT,
    TaskTypeId INT,
    Name varchar(255) NOT NULL,


    PRIMARY KEY (Id),
    CONSTRAINT FK_TaskTypeTask FOREIGN KEY (TaskTypeId)
    REFERENCES TaskType(Id)
); 



CREATE TABLE TaskTime(
    Id int NOT NULL AUTO_INCREMENT,
    StartDateTime DATETIME NOT NULL,
    EndDateTime DATETIME NULL,
    TaskId INT NOT NULL,
    
    PRIMARY	KEY	(Id),
    CONSTRAINT FK_TaskTimeTask FOREIGN KEY (TaskId)
    REFERENCES Task(Id)
);
    
