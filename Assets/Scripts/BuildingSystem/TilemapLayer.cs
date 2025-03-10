using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class TilemapLayer : MonoBehaviour
{
  protected Tilemap _tilemap { get; private set; }
  private void Awake()
  {
    _tilemap = GetComponent<Tilemap>();
  }
}
