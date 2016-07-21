SELECT * FROM users;

SELECT title, content FROM posts;

SELECT username, full_name FROM users
ORDER BY username ASC;

SELECT username, full_name FROM users
ORDER BY full_name DESC, username DESC;

SELECT * FROM users
WHERE id in (SELECT author_id FROM posts);

SELECT users.username, posts.title
FROM users JOIN posts ON users.id = posts.author_id;

SELECT username, full_name FROM users
WHERE id in (SELECT author_id FROM posts WHERE id = 4);

SELECT username, full_name FROM users
WHERE id in (SELECT author_id FROM posts ORDER BY id DESC);

INSERT INTO blog.posts (author_id, title, content, date)
VALUES (2, 'Random Title', 'Random Content', STR_TO_DATE('2016-07-06', '%Y-%m-%d'));

UPDATE blog.posts SET title = 'Too random to be true' WHERE id = 1;

DELETE FROM posts WHERE id = 1;