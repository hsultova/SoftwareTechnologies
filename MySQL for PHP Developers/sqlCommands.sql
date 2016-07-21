SELECT * FROM users;

SELECT username, full_name
FROM users;

SELECT * FROM users
WHERE username = 'teo';

SELECT * FROM users
WHERE full_name LIKE 'M%'
OR full_name LIKE 'P%';

SELECT * FROM users
ORDER BY username;

SELECT * FROM users
ORDER BY full_name DESC
LIMIT 3;

SELECT *
FROM posts JOIN users 
 ON posts.user_id = users.id;

SELECT p.title AS post,
u.username AS author
FROM posts p JOIN users u
ON p.user_id = u.id;

INSERT INTO posts(title, content, user_id)
VALUES ('New Title', 'New post content', 3);

INSERT INTO users(username, full_name) VALUES
  ('joe', 'Joe Green'),
  ('jeff', 'Jeff Brown'),
  ('poly', 'Paolina Code');
  
UPDATE posts
SET title = 'Title Updated!'
WHERE id = 2;

UPDATE posts
SET date = STR_TO_DATE('31-12-2016', '%d-%m-%Y')
WHERE YEAR(date) = 2016;

DELETE FROM posts
WHERE user_id = 
(SELECT id FROM users
WHERE username = 'joe');

INSERT INTO users(username, password, name)
VALUES ('pesho', '$xyz', 'Peter Ivanov');

UPDATE users
SET username = 'pepi'
WHERE username = 'pesho';

SELECT * FROM users
WHERE username LIKE 'p%';

DELETE FROM posts
WHERE user_id = 
(SELECT id FROM users
WHERE username = 'pepi');



