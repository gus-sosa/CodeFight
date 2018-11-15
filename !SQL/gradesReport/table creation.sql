CREATE TABLE `grades` (
  `grade` varchar(1) NOT NULL,
  `min_mark` int(11) NOT NULL,
  `max_mark` int(11) NOT NULL,
  UNIQUE KEY `grade_UNIQUE` (`grade`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

CREATE TABLE `students` (
  `name` varchar(50) NOT NULL,
  `mark` int(11) NOT NULL,
  UNIQUE KEY `name_UNIQUE` (`name`),
  UNIQUE KEY `mark_UNIQUE` (`mark`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci