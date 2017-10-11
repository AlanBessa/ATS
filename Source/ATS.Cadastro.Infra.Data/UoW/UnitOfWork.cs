using ATS.Cadastro.Infra.Data.Context;
using System.Data.Entity.Validation;
using System.Linq;

namespace ATS.Cadastro.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private CadastroContext _context;

        public UnitOfWork(CadastroContext dbContext)
        {
            _context = dbContext;
        }

        public void Commit()
        {
            //_context.SaveChanges();

            //Apagar depois do desenvolvimento estiver acertado
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
