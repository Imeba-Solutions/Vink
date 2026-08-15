import React from 'react';

const Navbar = () => {
  return (
    <header className="navbar-wrapper">
      <nav className="navbar container">
        <div className="nav-brand">
          <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><path d="M12 2L2 7l10 5 10-5-10-5zM2 17l10 5 10-5M2 12l10 5 10-5"/></svg>
          Vink
        </div>
        <ul className="nav-links">
          <li><a href="#funcionalidades">Funcionalidades</a></li>
          <li><a href="#tutoriales">Tutoriales y Guías</a></li>
          <li><a href="#precios">Precios</a></li>
          <li><a href="#clientes">¿Quiénes nos eligen?</a></li>
        </ul>
        <div className="nav-actions">
          <a href="#login" className="btn btn-outline btn-sm">Iniciar Sesión</a>
          <a href="#register" className="btn btn-primary btn-sm">Probalo Gratis</a>
        </div>
      </nav>
    </header>
  );
};

export default Navbar;
