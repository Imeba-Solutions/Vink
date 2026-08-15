import React from 'react';

const Footer = () => {
  return (
    <footer className="footer">
      <div className="container footer-content">
        <div className="footer-brand">
          <div className="nav-brand">
            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><path d="M12 2L2 7l10 5 10-5-10-5zM2 17l10 5 10-5M2 12l10 5 10-5"/></svg>
            Vink
          </div>
          <p>Tu software de gestión integral.</p>
        </div>
        <div className="footer-links">
          <div className="footer-col">
            <h4>Producto</h4>
            <ul>
              <li><a href="#funcionalidades">Funcionalidades</a></li>
              <li><a href="#precios">Precios</a></li>
              <li><a href="#novedades">Novedades</a></li>
            </ul>
          </div>
          <div className="footer-col">
            <h4>Recursos</h4>
            <ul>
              <li><a href="#blog">Blog</a></li>
              <li><a href="#tutoriales">Tutoriales</a></li>
              <li><a href="#ayuda">Centro de Ayuda</a></li>
            </ul>
          </div>
          <div className="footer-col">
            <h4>Legal</h4>
            <ul>
              <li><a href="#terminos">Términos y Condiciones</a></li>
              <li><a href="#privacidad">Política de Privacidad</a></li>
            </ul>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
