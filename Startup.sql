-- BOOKS TABLE

-- CREATE TABLE books (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     author VARCHAR(255),
--     libraryId INT NOT NULL,
--     isAvailable TINYINT,

--     PRIMARY KEY (id),
--     FOREIGN KEY (libraryId)
--       REFERENCES libraries(id)
--         ON DELETE CASCADE
-- )
-- CREATE TABLE libraries (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     location VARCHAR(255),

--     PRIMARY KEY (id)
    

-- )


-- CREATE TABLE authors (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )



-- CREATE TABLE bookauthors (
--     id INT NOT NULL AUTO_INCREMENT,
--     bookId INT NOT NULL,
--     authorId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (authorId)
--         REFERENCES authors(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (bookId)
--         REFERENCES books(id)
--         ON DELETE CASCADE
-- )