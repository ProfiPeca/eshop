DROP DATABASE IF EXISTS eshop;
CREATE DATABASE eshop;
USE eshop;
CREATE TABLE user (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('ADMIN','CUSTOMER') NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT 1
);
CREATE TABLE customer (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    registered_at DATETIME NOT NULL
);
CREATE TABLE product (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    price FLOAT NOT NULL,
    category ENUM('BOOK','ELECTRONICS','FOOD') NOT NULL,
    in_stock BOOLEAN NOT NULL
);
CREATE TABLE `order` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    created_at DATETIME NOT NULL,
    total_price FLOAT NOT NULL,
    CONSTRAINT fk_order_customer
        FOREIGN KEY (customer_id) REFERENCES customer(id)
        ON DELETE CASCADE
);
CREATE TABLE order_item (
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY (order_id, product_id),
    CONSTRAINT fk_item_order
        FOREIGN KEY (order_id) REFERENCES `order`(id)
        ON DELETE CASCADE,
    CONSTRAINT fk_item_product
        FOREIGN KEY (product_id) REFERENCES product(id)
);
CREATE VIEW v_order_summary AS
SELECT
    o.id AS order_id,
    c.name AS customer_name,
    o.total_price,
    o.created_at
FROM `order` o
JOIN customer c ON o.customer_id = c.id;

CREATE VIEW v_customer_order_report AS
SELECT 
    c.id AS customer_id,
    c.name AS customer_name,
    COUNT(o.id) AS order_count,
    SUM(o.total_price) AS total_spent,
    MIN(o.created_at) AS first_order,
    MAX(o.created_at) AS last_order
FROM customer c
JOIN `order` o ON c.id = o.customer_id
JOIN order_item oi ON o.id = oi.order_id
GROUP BY c.id, c.name;

INSERT INTO user (username, password_hash, role, is_active)
VALUES ('admin', 'admin', 'ADMIN', 1);

INSERT INTO customer (name, email, registered_at)
VALUES ('Testovací zákazník', 'test@test.cz', NOW());

INSERT INTO product (name, price, category, in_stock)
VALUES 
('Kniha C#', 599, 'BOOK', 1),
('Notebook', 19999, 'ELECTRONICS', 1),
('Èokoláda', 49, 'FOOD', 1);