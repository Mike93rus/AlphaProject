-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Апр 22 2021 г., 17:10
-- Версия сервера: 10.4.18-MariaDB
-- Версия PHP: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `alphabd`
--

DELIMITER $$
--
-- Процедуры
--
CREATE DEFINER=`user`@`%` PROCEDURE `GetKlientsAndProjectGroup` ()  READS SQL DATA
SELECT CONCAT(k.fam, ' ', k.name, ' ', k.otch) AS FIO, k.organization, k.inn, k.email, k.tel, COUNT(p.id), SUM(p.stoimost) FROM klient k INNER JOIN project p ON k.id = p.id_klient GROUP BY CONCAT(k.fam, ' ', k.name, ' ', k.otch), k.organization, k.inn, k.email, k.tel$$

CREATE DEFINER=`user`@`%` PROCEDURE `GetKlientsAndProjects` (IN `fioorg` VARCHAR(120))  READS SQL DATA
SELECT CONCAT(k.fam, ' ', k.name, ' ', k.otch) AS FIO, k.organization, k.inn, k.email, k.tel, p.project_name, p.date, p.plan_date, s.status, p.stoimost FROM klient k INNER JOIN project p ON k.id = p.id_klient INNER JOIN project_status s ON p.status_id = s.id WHERE CONCAT(k.fam, ' ', k.name, ' ', k.otch, k.organization) LIKE CONCAT('%', fioorg, '%')$$

CREATE DEFINER=`user`@`%` PROCEDURE `GetProjectAndDocs` ()  READS SQL DATA
SELECT p.project_name, s.status, COUNT(d.id), st.state FROM project_status s INNER JOIN project p ON s.id = p.status_id INNER JOIN docs d ON p.id = d.id_project INNER JOIN doc_state st ON d.state_id = st.id GROUP BY p.project_name, s.status, st.state ORDER BY p.project_name$$

CREATE DEFINER=`user`@`%` PROCEDURE `GetProjectDetail` (IN `date1` DATE, IN `date2` DATE)  READS SQL DATA
SELECT p.project_name, k.organization, p.date, p.plan_date, s.status, p.stoimost, COUNT(d.id) FROM project_status s INNER JOIN project p ON s.id = p.status_id INNER JOIN docs d ON p.id = d.id_project INNER JOIN klient k ON k.id = p.id_klient WHERE p.plan_date BETWEEN date1 AND date2 GROUP BY p.project_name, k.organization, p.date, p.plan_date, s.status, p.stoimost$$

CREATE DEFINER=`user`@`%` PROCEDURE `GetSotrAndDocs` (IN `fio` VARCHAR(120))  READS SQL DATA
SELECT CONCAT(s.fam, ' ', s.name, ' ', s.otch) AS FIO, dolz.dolznost, s.email, s.tel, p.project_name, d.doc_name FROM project p INNER JOIN docs d ON p.id = d.id_project INNER JOIN sotrudnik s ON d.id_sotr = s.id INNER JOIN dolznost dolz ON s.dolznost_id = dolz.id WHERE CONCAT(s.fam, ' ', s.name, ' ', s.otch) LIKE CONCAT('%', fio, '%')$$

CREATE DEFINER=`user`@`%` PROCEDURE `GetSotrAndDocsGroup` ()  READS SQL DATA
SELECT CONCAT(s.fam, ' ', s.name, ' ', s.otch) AS FIO, dolz.dolznost, s.email, s.tel, COUNT(d.id) FROM docs d INNER JOIN sotrudnik s ON d.id_sotr = s.id INNER JOIN dolznost dolz ON s.dolznost_id = dolz.id GROUP BY CONCAT(s.fam, ' ', s.name, ' ', s.otch), dolz.dolznost, s.email, s.tel$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Структура таблицы `docs`
--

CREATE TABLE `docs` (
  `id` int(5) NOT NULL,
  `id_sotr` int(3) NOT NULL,
  `id_project` int(3) NOT NULL,
  `doc_name` varchar(80) COLLATE utf8mb4_unicode_ci NOT NULL,
  `doc_file` mediumblob NOT NULL,
  `state_id` tinyint(1) NOT NULL,
  `type_id` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `doc_state`
--

CREATE TABLE `doc_state` (
  `id` tinyint(1) NOT NULL,
  `state` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `doc_state`
--

INSERT INTO `doc_state` (`id`, `state`) VALUES
(1, 'Итог'),
(2, 'На экспертизу'),
(3, 'Рабочая');

-- --------------------------------------------------------

--
-- Структура таблицы `doc_type`
--

CREATE TABLE `doc_type` (
  `id` tinyint(1) NOT NULL,
  `type` varchar(25) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `doc_type`
--

INSERT INTO `doc_type` (`id`, `type`) VALUES
(1, 'Исходно-разрешительная'),
(2, 'Сметная'),
(3, 'Иная');

-- --------------------------------------------------------

--
-- Структура таблицы `dolznost`
--

CREATE TABLE `dolznost` (
  `id` tinyint(2) NOT NULL,
  `dolznost` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `accesslvl` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `dolznost`
--

INSERT INTO `dolznost` (`id`, `dolznost`, `accesslvl`) VALUES
(1, 'Ген директор', 1),
(2, 'Зам ген директор', 1),
(3, 'Главный проектировщик', 2),
(4, 'Инженер-проектировщик', 3),
(5, 'Менеджер', 4),
(6, 'Администратор', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `klient`
--

CREATE TABLE `klient` (
  `id` int(3) NOT NULL,
  `name` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `fam` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `otch` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `organization` varchar(60) COLLATE utf8mb4_unicode_ci NOT NULL,
  `inn` int(12) NOT NULL,
  `email` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tel` varchar(11) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `klient`
--

INSERT INTO `klient` (`id`, `name`, `fam`, `otch`, `organization`, `inn`, `email`, `tel`) VALUES
(1, 'Данила ', 'Дорофеев', 'Артемович', 'ООО \"Догма\"', 2034041221, 'dorofart@gmail.com', '89605739741'),
(2, 'Якупов', 'Вячеслав', 'Олегович', 'МАОУ СОШ№7 г. Краснодар', 1000323442, 'plast7@gmail.com', '89674636154');

-- --------------------------------------------------------

--
-- Структура таблицы `project`
--

CREATE TABLE `project` (
  `id` int(3) NOT NULL,
  `id_klient` int(3) NOT NULL,
  `project_name` varchar(120) COLLATE utf8mb4_unicode_ci NOT NULL,
  `date` date NOT NULL,
  `plan_date` date NOT NULL,
  `status_id` tinyint(1) NOT NULL,
  `stoimost` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `project`
--

INSERT INTO `project` (`id`, `id_klient`, `project_name`, `date`, `plan_date`, `status_id`, `stoimost`) VALUES
(2, 2, 'СОШ№7 Пластуновская  (Кап. ремонт)', '2020-03-03', '2020-04-28', 2, 1200000),
(3, 1, 'Догма корпус 2б', '2020-04-15', '2020-07-22', 1, 2200000);

-- --------------------------------------------------------

--
-- Структура таблицы `project_status`
--

CREATE TABLE `project_status` (
  `id` tinyint(1) NOT NULL,
  `status` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `project_status`
--

INSERT INTO `project_status` (`id`, `status`) VALUES
(1, 'В работе'),
(2, 'Выполнен'),
(3, 'Запланирован'),
(4, 'На экспертизе');

-- --------------------------------------------------------

--
-- Структура таблицы `sotrudnik`
--

CREATE TABLE `sotrudnik` (
  `id` int(3) NOT NULL,
  `fam` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `name` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `otch` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `dolznost_id` tinyint(2) NOT NULL,
  `email` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tel` varchar(11) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pol` varchar(3) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `sotrudnik`
--

INSERT INTO `sotrudnik` (`id`, `fam`, `name`, `otch`, `dolznost_id`, `email`, `tel`, `pol`, `password`) VALUES
(1, 'Соколов', 'Данила', 'Евгеньевич', 2, 'sokeug@yandex.ru', '88004437211', 'Муж', 'qwerty'),
(2, 'Логвинов', 'Николай', 'Александрович', 4, 'ууу', '89603759277', 'Муж', '1111');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `docs`
--
ALTER TABLE `docs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `docs_ibfk_1` (`id_project`),
  ADD KEY `docs_ibfk_2` (`state_id`),
  ADD KEY `docs_ibfk_3` (`type_id`),
  ADD KEY `docs_ibfk_4` (`id_sotr`);

--
-- Индексы таблицы `doc_state`
--
ALTER TABLE `doc_state`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `doc_type`
--
ALTER TABLE `doc_type`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `dolznost`
--
ALTER TABLE `dolznost`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `klient`
--
ALTER TABLE `klient`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `project`
--
ALTER TABLE `project`
  ADD PRIMARY KEY (`id`),
  ADD KEY `project_ibfk_1` (`id_klient`),
  ADD KEY `project_ibfk_2` (`status_id`);

--
-- Индексы таблицы `project_status`
--
ALTER TABLE `project_status`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `sotrudnik`
--
ALTER TABLE `sotrudnik`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sotrudnik_ibfk_1` (`dolznost_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `docs`
--
ALTER TABLE `docs`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `doc_state`
--
ALTER TABLE `doc_state`
  MODIFY `id` tinyint(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `doc_type`
--
ALTER TABLE `doc_type`
  MODIFY `id` tinyint(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `dolznost`
--
ALTER TABLE `dolznost`
  MODIFY `id` tinyint(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `klient`
--
ALTER TABLE `klient`
  MODIFY `id` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `project`
--
ALTER TABLE `project`
  MODIFY `id` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `project_status`
--
ALTER TABLE `project_status`
  MODIFY `id` tinyint(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `sotrudnik`
--
ALTER TABLE `sotrudnik`
  MODIFY `id` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `docs`
--
ALTER TABLE `docs`
  ADD CONSTRAINT `docs_ibfk_1` FOREIGN KEY (`id_project`) REFERENCES `project` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `docs_ibfk_2` FOREIGN KEY (`state_id`) REFERENCES `doc_state` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `docs_ibfk_3` FOREIGN KEY (`type_id`) REFERENCES `doc_type` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `docs_ibfk_4` FOREIGN KEY (`id_sotr`) REFERENCES `sotrudnik` (`id`);

--
-- Ограничения внешнего ключа таблицы `project`
--
ALTER TABLE `project`
  ADD CONSTRAINT `project_ibfk_1` FOREIGN KEY (`id_klient`) REFERENCES `klient` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `project_ibfk_2` FOREIGN KEY (`status_id`) REFERENCES `project_status` (`id`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `sotrudnik`
--
ALTER TABLE `sotrudnik`
  ADD CONSTRAINT `sotrudnik_ibfk_1` FOREIGN KEY (`dolznost_id`) REFERENCES `dolznost` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
