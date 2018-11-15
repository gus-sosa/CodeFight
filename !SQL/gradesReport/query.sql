SELECT CASE WHEN g.grade>'C' THEN NULL ELSE s.name END AS name, g.grade ,s.mark
FROM students s
JOIN grades g ON s.mark>=g.min_mark AND s.mark<=g.max_mark
ORDER BY g.grade,name,s.mark asc;