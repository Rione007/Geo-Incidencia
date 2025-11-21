CREATE PROCEDURE SP_BUSCAR_POR_AREA
(
    @MinLat    DECIMAL(10,7),
    @MaxLat    DECIMAL(10,7),
    @MinLng    DECIMAL(10,7),
    @MaxLng    DECIMAL(10,7),

    @ListaTipos     VARCHAR(MAX) = NULL,   -- Ej: '1,3,5'
    @ListaSubtipos  VARCHAR(MAX) = NULL,   -- Ej: '10,11,12'
    @Dias           INT = NULL             -- Últimos X días
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Convertir lista de tipos a tabla
    DECLARE @Tipos TABLE (Id INT);
    IF(@ListaTipos IS NOT NULL AND @ListaTipos <> '')
        INSERT INTO @Tipos SELECT value FROM STRING_SPLIT(@ListaTipos, ',');

    -- Convertir lista de subtipos a tabla
    DECLARE @Subtipos TABLE (Id INT);
    IF(@ListaSubtipos IS NOT NULL AND @ListaSubtipos <> '')
        INSERT INTO @Subtipos SELECT value FROM STRING_SPLIT(@ListaSubtipos, ',');

    SELECT
        ID_INCIDENCIA,
        LATITUD,
        LONGITUD,
        ID_TIPO,
        ID_SUBTIPO,
        FECHA_REGISTRO,
        DESCRIPCION,
        ESTADO
    FROM INCIDENCIA
    WHERE LATITUD BETWEEN @MinLat AND @MaxLat
      AND LONGITUD BETWEEN @MinLng AND @MaxLng
      
      -- Filtros opcionales MULTIPLES
      AND (
            @ListaTipos IS NULL
            OR ID_TIPO IN (SELECT Id FROM @Tipos)
          )

      AND (
            @ListaSubtipos IS NULL
            OR ID_SUBTIPO IN (SELECT Id FROM @Subtipos)
          )

      -- Filtro por días (últimos X días)
      AND (
            @Dias IS NULL
            OR FECHA_REGISTRO >= DATEADD(DAY, -@Dias, GETDATE())
          )

    ORDER BY FECHA_REGISTRO DESC;

END
