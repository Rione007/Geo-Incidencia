CREATE PROCEDURE SP_OBTENER_HEATMAP
(
    @MinLat DECIMAL(10,7),
    @MaxLat DECIMAL(10,7),
    @MinLon DECIMAL(10,7),
    @MaxLon DECIMAL(10,7),
    @TamCelda DECIMAL(10,7) = 0.01   -- tamaño de la celda
)
AS
BEGIN
    SELECT  
        FLOOR(LATITUD  / @TamCelda) AS CeldaLat,   -- ID de la celda
        FLOOR(LONGITUD / @TamCelda) AS CeldaLon,   -- ID de la celda
        COUNT(*) AS Cantidad                       -- número de incidencias en esa celda
    FROM INCIDENCIA
    WHERE LATITUD  BETWEEN @MinLat AND @MaxLat     -- área visible
      AND LONGITUD BETWEEN @MinLon AND @MaxLon
    GROUP BY 
        FLOOR(LATITUD  / @TamCelda),
        FLOOR(LONGITUD / @TamCelda);
END
