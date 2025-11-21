CREATE PROCEDURE SP_REGISTRAR_INCIDENCIA
(
    @IdUsuario      INT,
    @Latitud        DECIMAL(10,7),
    @Longitud       DECIMAL(10,7),
    @TipoId         INT,
    @SubtipoId      INT,
    @Descripcion    VARCHAR(500),
    @FechaIncidencia  DATETIME = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        
        IF @FechaIncidencia IS NULL
            SET @FechaIncidencia = GETDATE();

        INSERT INTO INCIDENCIA
        (
            ID_USUARIO,
            LATITUD,
            LONGITUD,
            ID_TIPO,
            ID_SUBTIPO,
            DESCRIPCION,
            FECHA_REGISTRO,
            ESTADO
        )
        VALUES
        (
            @IdUsuario,
            @Latitud,
            @Longitud,
            @TipoId,
            @SubtipoId,
            @Descripcion,
            @FechaIncidencia,
            1 -- Estado por defecto (activo, registrado)
        );

        SELECT 
            1 AS Fila,
            'Incidencia registrada correctamente' AS Mensaje,
            SCOPE_IDENTITY() AS Id;
    
    END TRY
    BEGIN CATCH

        SELECT 
            0 AS Fila,
            ERROR_MESSAGE() AS Mensaje,
            NULL AS Id;

    END CATCH
END
