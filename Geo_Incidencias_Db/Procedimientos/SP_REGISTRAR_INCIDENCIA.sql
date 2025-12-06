CREATE PROCEDURE dbo.SP_REGISTRAR_INCIDENCIA
(
    @IdUsuario           INT,
    @Latitud             DECIMAL(10,7),
    @Longitud            DECIMAL(10,7),
    @TipoId              INT,
    @SubtipoId           INT,
    @Descripcion         VARCHAR(500),
    @DireccionReferencia VARCHAR(250) = NULL,
    @FotoUrl1            VARCHAR(500) = NULL,
    @FotoUrl2            VARCHAR(500) = NULL,
    @FotoUrl3            VARCHAR(500) = NULL,
    @FechaIncidencia     DATETIME = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @FechaIncidencia IS NULL
            SET @FechaIncidencia = GETDATE();

        INSERT INTO dbo.INCIDENCIA
        (
            ID_USUARIO,
            LATITUD,
            LONGITUD,
            ID_TIPO,
            ID_SUBTIPO,
            DESCRIPCION,
            DIRECCION_REFERENCIA,
            FOTO_URL1,
            FOTO_URL2,
            FOTO_URL3,
            FECHA_INCIDENCIA,
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
            @DireccionReferencia,
            @FotoUrl1,
            @FotoUrl2,
            @FotoUrl3,
            @FechaIncidencia,
            GETDATE(),
            1
        );

        SELECT 
            1 AS Fila,
            'Incidencia registrada correctamente' AS Mensaje,
            CAST(SCOPE_IDENTITY() AS INT) AS Id;
    END TRY
    BEGIN CATCH
        SELECT 
            0 AS Fila,
            ERROR_MESSAGE() AS Mensaje,
            NULL AS Id;
    END CATCH
END;
GO