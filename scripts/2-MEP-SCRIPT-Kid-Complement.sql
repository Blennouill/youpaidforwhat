DELIMITER $$
--
-- Procédures
--
CREATE PROCEDURE `PS_SUPPRIMER_EVENEMENT`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
    COMMENT 'Permet de supprimer les évènements échus.'
BEGIN
    Delete b
	from bilan b
	where b.estCloture = 1 and DATE_ADD(b.dateCloture, INTERVAL 2 MONTH) < current_date();
    
	Delete e
	from evenement e 
	inner join bilan b on b.id = e.idBilan
	where b.estCloture = 1 and DATE_ADD(b.dateCloture, INTERVAL 2 MONTH) < CURRENT_DATE;
END$$

DELIMITER ;

DELIMITER $$
--
-- Événements
--
CREATE EVENT `EVENT_EXEC_SUPPRIMER_EVENEMENT` ON SCHEDULE EVERY 1 DAY STARTS '2015-06-19 01:00:00' ON COMPLETION PRESERVE ENABLE DO CALL PS_SUPPRIMER_EVENEMENT$$