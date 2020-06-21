
CREATE USER 'Login_lekarz'@'localhost' IDENTIFIED BY 'haslolekarz';
GRANT SELECT,INSERT,UPDATE,DELETE ON przychodnia.wizyta TO 'Login_lekarz'@'localhost' IDENTIFIED BY 'haslolekarz';

CREATE USER 'Login_recepcja'@'localhost' IDENTIFIED BY 'haslorecepcja';
GRANT SELECT,INSERT,UPDATE,DELETE ON przychodnia.* TO 'Login_recepcja'@'localhost' IDENTIFIED BY 'haslorecepcja';






