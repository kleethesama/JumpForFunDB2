USE JumpForFun;

-- Creating a new login for user,
-- creating a new role with execute and insert rights,
-- then finally assigning that role to the user.
CREATE ROLE clerk;
GRANT EXECUTE TO clerk;
GRANT INSERT TO clerk;
CREATE LOGIN frede WITH PASSWORD = 'mitKodeOrd';
ALTER ROLE clerk ADD MEMBER frede;
GO