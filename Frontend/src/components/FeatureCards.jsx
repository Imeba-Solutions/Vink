import React from 'react';

const FeatureCards = () => {
  const features = [
    { title: "Gestión de Turnos", desc: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor.", icon: "📅" },
    { title: "Historias Clínicas", desc: "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi.", icon: "📝" },
    { title: "Videollamadas", desc: "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore.", icon: "🎥" },
    { title: "Pagos y Facturación", desc: "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia.", icon: "💳" },
    { title: "Notificaciones", desc: "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit.", icon: "🔔" },
    { title: "Métricas", desc: "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur.", icon: "📊" },
  ];

  return (
    <section className="features-section container" id="funcionalidades">
      <div className="section-header">
        <h2>Todo lo que necesitás en un solo lugar</h2>
        <p>Descubrí todas las herramientas que Vink tiene preparadas para facilitar tu trabajo diario.</p>
      </div>
      <div className="features-grid">
        {features.map((f, i) => (
          <div key={i} className="feature-card">
            <div className="feature-icon-text">{f.icon}</div>
            <h3>{f.title}</h3>
            <p>{f.desc}</p>
          </div>
        ))}
      </div>
    </section>
  );
};

export default FeatureCards;
