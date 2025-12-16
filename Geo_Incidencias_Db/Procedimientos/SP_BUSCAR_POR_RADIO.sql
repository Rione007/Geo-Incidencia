CREATE PROCEDURE SP_BUSCAR_POR_RADIO
(
    @Lat DECIMAL(10,7),
    @Lng DECIMAL(10,7),
    @Metros FLOAT,
    @ListaTipos VARCHAR(MAX) = NULL,
    @ListaSubtipos VARCHAR(MAX) = NULL,
    @FechaDesde DATETIME = NULL,
    @FechaHasta DATETIME = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @EarthRadiusKm FLOAT = 6371.0;

    -- Convertir listas a tablas
    DECLARE @Tipos TABLE (Id INT);
    DECLARE @Subtipos TABLE (Id INT);

    IF(@ListaTipos IS NOT NULL)
        INSERT INTO @Tipos SELECT value FROM STRING_SPLIT(@ListaTipos, ',');

    IF(@ListaSubtipos IS NOT NULL)
        INSERT INTO @Subtipos SELECT value FROM STRING_SPLIT(@ListaSubtipos, ',');

    -- Query principal
    SELECT *
    FROM (
        SELECT 
            I.*,

            @EarthRadiusKm * 1000 *
            ACOS(
                COS(RADIANS(@Lat)) * COS(RADIANS(I.LATITUD)) *
                COS(RADIANS(I.LONGITUD) - RADIANS(@Lng)) +
                SIN(RADIANS(@Lat)) * SIN(RADIANS(I.LATITUD))
            ) AS DistanciaMetros
        FROM INCIDENCIA I
    ) X
    WHERE X.DistanciaMetros <= @Metros
      AND (@ListaTipos IS NULL OR X.ID_TIPO IN (SELECT Id FROM @Tipos))
      AND (@ListaSubtipos IS NULL OR X.ID_SUBTIPO IN (SELECT Id FROM @Subtipos))
      AND (@FechaDesde IS NULL OR FECHA_REGISTRO >= @FechaDesde)
      AND (@FechaHasta IS NULL OR FECHA_REGISTRO < DATEADD(DAY, 1, @FechaHasta))
    ORDER BY FECHA_REGISTRO DESC;

END
