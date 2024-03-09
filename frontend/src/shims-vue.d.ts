//este archivo sirvew para indicar a typescript como hacer las importaciones de componentes .vue
declare module '*.vue' {
    import { DefineComponent } from 'vue';
    const component: DefineComponent<{}, {}, any>;
    export default component;
  }