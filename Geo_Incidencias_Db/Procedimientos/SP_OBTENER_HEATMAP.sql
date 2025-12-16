CREATE PROCEDURE [dbo].[SP_OBTENER_HEATMAP]
(
    @MinLat DECIMAL(10,7),
    @MaxLat DECIMAL(10,7),
    @MinLon DECIMAL(10,7),
    @MaxLon DECIMAL(10,7),
    @TamCelda DECIMAL(10,7) = 0.01,   -- tamaño de la celda
    @ListaTipos VARCHAR(MAX) = NULL,
    @ListaSubtipos VARCHAR(MAX) = NULL,
    @FechaDesde DATETIME = NULL,
    @FechaHasta DATETIME = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Tipos TABLE (Id INT);
    DECLARE @Subtipos TABLE (Id INT);

    IF(@ListaTipos IS NOT NULL AND @ListaTipos <> '')
        INSERT INTO @Tipos SELECT value FROM STRING_SPLIT(@ListaTipos, ',');

    IF(@ListaSubtipos IS NOT NULL AND @ListaSubtipos <> '')
        INSERT INTO @Subtipos SELECT value FROM STRING_SPLIT(@ListaSubtipos, ',');

    SELECT  
        (FLOOR(LATITUD  / @TamCelda) + 0.5) * @TamCelda AS CentroLat,
        (FLOOR(LONGITUD / @TamCelda) + 0.5) * @TamCelda AS CentroLng,
        COUNT(*) AS Cantidad
    FROM INCIDENCIA
    WHERE LATITUD  BETWEEN @MinLat AND @MaxLat
      AND LONGITUD BETWEEN @MinLon AND @MaxLon
      AND (@ListaTipos IS NULL OR ID_TIPO IN (SELECT Id FROM @Tipos))
      AND (@ListaSubtipos IS NULL OR ID_SUBTIPO IN (SELECT Id FROM @Subtipos))
      AND (@FechaDesde IS NULL OR FECHA_REGISTRO >= @FechaDesde)
      AND (@FechaHasta IS NULL OR FECHA_REGISTRO < DATEADD(DAY, 1, @FechaHasta))
    GROUP BY 
        FLOOR(LATITUD  / @TamCelda),
        FLOOR(LONGITUD / @TamCelda);
END
