CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_USUARIO]
    @ID_USUARIO        INT,
    @NOMBRE            VARCHAR(100) = NULL,
    @CONTRASENA_HASH   VARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FILA INT = 0;
    DECLARE @ERROR INT = 0;
    DECLARE @MENSAJE NVARCHAR(200) = '';

    BEGIN TRY
        BEGIN TRAN;

        -- 1) Verificar si existe el usuario
        IF NOT EXISTS (SELECT 1 FROM dbo.USUARIO WHERE ID_USUARIO = @ID_USUARIO)
        BEGIN
            SET @ERROR = 1;
            SET @MENSAJE = 'El usuario no existe.';
        END
        ELSE
        BEGIN
                -- 3b) Actualizar sin tocar EMAIL
                UPDATE dbo.USUARIO
                SET
                    NOMBRE          = COALESCE(@NOMBRE, NOMBRE),
                    CONTRASENA_HASH = COALESCE(@CONTRASENA_HASH, CONTRASENA_HASH)
                WHERE ID_USUARIO = @ID_USUARIO;

                SET @FILA = @@ROWCOUNT;
                SET @MENSAJE = CASE WHEN @FILA = 1 THEN 'Usuario actualizado correctamente.'
                                    ELSE 'Sin cambios.' END;
        END

        IF @ERROR = 0
            COMMIT TRAN;
        ELSE
            ROLLBACK TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN;
        SET @ERROR = ERROR_NUMBER();
        SET @MENSAJE = ERROR_MESSAGE();
        SET @FILA = 0;
    END CATCH;

    SELECT
        ID      = @ID_USUARIO,
        FILA    = @FILA,
        [ERROR] = @ERROR,
        MENSAJE = @MENSAJE;
END;